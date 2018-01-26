using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Variance;
using GameEventing.GameEvents;
using GameEventing.GameEvents.EventData;
using GameEventing.GameEvents.Events;
using GameEventing.GameObjects.Items;
using MediatR;
using Newtonsoft.Json;

namespace GameEventing
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var mediator = container.Resolve<IMediator>();
            var stateSaver = new StateSaver("Game1");
            
            var game = new Game(mediator, stateSaver);



            for (int i = 0; i < 10000; i++)
            {
                game.AddGameEvent("Added John 117",
                    new CharacterAddedEventData(Guid.NewGuid(), "John 117", 100, 100, 50, 100)).GetAwaiter().GetResult();
            }
            //game.AddItem(new Weapon(Guid.NewGuid(), "Sword of Power", 103, 10, 111, 12,15));
            //game.AddItem(new Weapon(Guid.NewGuid(), "Wand of Magic", 99, 1, 12, 53,87));

            //var spartanJohn = game.AddCharacter(Guid.NewGuid(), "John 117", 100, 100, 50, 100);
            //spartanJohn.Move(51,101);

            //var save = JsonConvert.SerializeObject(game.GameEvents);
            //using (var sw = new StreamWriter("events.json"))
            //{
            //    sw.Write(save);
            //    sw.Flush();
            //}
            
        }


        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestHandler<>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(IEventData).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            //builder.RegisterInstance(writer).As<TextWriter>();

            // It appears Autofac returns the last registered types first
            //builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(GenericRequestPreProcessor<>)).As(typeof(IRequestPreProcessor<>));
            //builder.RegisterGeneric(typeof(GenericRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
            //builder.RegisterGeneric(typeof(GenericPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(ConstrainedRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
            //builder.RegisterGeneric(typeof(ConstrainedPingedHandler<>)).As(typeof(INotificationHandler<>));

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            

            var container = builder.Build();

            // The below returns:
            //  - RequestPreProcessorBehavior
            //  - RequestPostProcessorBehavior
            //  - GenericPipelineBehavior

            //var behaviors = container
            //    .Resolve<IEnumerable<IPipelineBehavior<Ping, Pong>>>()
            //    .ToList();

            return container;
            
        }
    }
}
