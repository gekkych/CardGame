using System.Collections.Generic;
using System.Linq;
using BattleEngine.Work;

namespace BattleEngine
{
    public class WorkScheduler
    {
        private Stack<WorkItem> _standard = new();
        private SortedDictionary<int, Stack<WorkItem>> _schedule = new();

        private void Schedule(WorkItem workItem)
        {
            if (!_schedule.TryGetValue(workItem.Priority, out var stack))
            {
                stack = new Stack<WorkItem>();
                _schedule.Add(workItem.Priority, stack);
            }

            stack.Push(workItem);
        }

        private bool IsEmptySchedule()
        {
            return _schedule.Values.All(stack => stack.Count == 0);
        }
        
        public void Push(WorkItem workItem)
        {
            if (workItem == null) return;
            
            if (workItem.Priority != 0)
            {
                Schedule(workItem);
            }
            else
            {
                _standard.Push(workItem);
            }
        }

        // [A, B, C] + Stack[D, E] -> Stack [A, B, C, D, E] (pop will return A)
        public void PushRange(IEnumerable<WorkItem> workItems)
        {
            foreach (var workItem in workItems.Reverse())
            {
                Push(workItem);
            }
        }

        public bool TryPop(out WorkItem workItem)
        {
            foreach (var stack in _schedule.Values)
            {
                if (stack.Count == 0)
                    continue;

                workItem = stack.Pop();
                return true;
            }

            if (_standard.Count > 0)
            {
                workItem = _standard.Pop();
                return true;
            }

            workItem = null;
            return false;
        }
        
    }
}