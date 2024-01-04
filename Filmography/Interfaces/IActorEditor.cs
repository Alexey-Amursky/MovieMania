using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography.Interfaces
{
    public interface IActorEditor
    {
        void AddActor(Actor actor);
        void EditActor(int movieIndex, int actorIndex, Actor updatedActor);
        void DeleteActor(int movieIndex, int actorIndex);
    }
}
