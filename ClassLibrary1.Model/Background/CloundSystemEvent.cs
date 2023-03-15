using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class CloundSystemEvent
    {
        private static CloundSystemEvent? _instand;

        public static CloundSystemEvent Instand { get => _instand = (_instand ?? new CloundSystemEvent()); }

        public event Action<Guid> TaskCreated = (taskId) => { };

        public CloundSystemEvent()
        {

        }

        public void OnTaskCreate(Guid taskId) => TaskCreated?.Invoke(taskId);
    }
}
