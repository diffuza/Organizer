using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace Organizer
{
    public class Organizer
    {
        public List<Data> List = new List<Data>();
        public Organizer(Data data)
        {

            List.Add(data);
        }
        public Organizer()
        {


        }


        public void add(Data data)
        {
            this.List.Add(data);
        }
        public void remove(int index)
        {
            if (index < List.Count)
                List.RemoveAt(index);
        }
        public List<Data> findByTime(String time)
        {
            List<Data> tmplist = new List<Data>();
            List.ForEach(item =>
            {
                int time1 = item.Time.Hours * 3600 + item.Time.Minutes;
                int time2 = int.Parse(time.Split(':')[0]) * 3600 + int.Parse(time.Split(':')[1]);
                if (time2 >= time1)
                    tmplist.Add(item);
            });
            return tmplist;
        }
        public List<Data> findByCategory(EventType type )
        {
            List<Data> tmpList = new List<Data>();
            List.ForEach(item =>
            {
                if (item.eventType==type)
                    tmpList.Add(item);
            });
            return tmpList;
        }

        public List<Data> findByText(String text)
        {
            List<Data> tmpList = new List<Data>();
            List.ForEach(item =>
            {
                if (item.Event.IndexOf(text) >= 0)
                    tmpList.Add(item);
            });
            return tmpList;
        }
        public void sortByEvent(int direction = 0)
        {
            List.Sort((x, y) => direction == 0 ?
            String.Compare(x.Event, y.Event) :
            String.Compare(y.Event, x.Event)
            );
        }
        public void sortByTime(int direction = 0)
        {
            List.Sort((x, y) =>
            {
                int timeX = x.Time.Hours * 3600 + x.Time.Minutes;
                int timeY = y.Time.Hours * 3600 + y.Time.Minutes;
                if (direction == 0)
                {
                    if (timeX > timeY)
                        return 1;
                    if (timeX < timeY)
                        return -1;
                    if (timeX == timeY)
                        return 0;
                }
                if (direction == 1)
                {
                    if (timeX > timeY)
                        return -1;
                    if (timeX < timeY)
                        return 1;
                    if (timeX == timeY)
                        return 0;
                }
                return 0;
            }
                    
            
            
            );
        }
    }
}
