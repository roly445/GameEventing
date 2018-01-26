using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GameEventing.GameEvents
{
    public interface IGameEvent<out TEventData> : IRequest where TEventData : IEventData
    {
        Game Game { get; }
        TEventData Data { get; }
    }
}
