using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class TicketQueryOption
    {
        public enum SituationType
        {
            WaitingAttendantIteraction,
            NotStarted,
            WaitingClientReply,
            WaitingAttendantReply,
            Canceled,
            Finished,
            AttendantChanged,
            SentToSupportTeam,
            WaitingManagerAvaliation,
            WaitingManagerAvaliation2
        }

        public enum OrderType
        {
            Increasing,
            Decreasing
        }

        public string ClientId { get; set; }
        public string IdType { get; set; }
        public List<SituationType> Situations { get; set; }
        public OrderType Order { get; set; }
        public string Column { get; set; }
        public int LastSituationLesser { get; set; }
        public int LastSituationUpper { get; set; }
        public string DepartmentId { get; set; }
        public string Status { get; set; }
        public string Organization { get; set; }
        public int ProtocolMin { get; set; }
        public int ProtocolMax { get; set; }

        public string StringfySituations()
        {
            string str = "";

            Situations.ForEach(x => str += $"{(int)x},");

            str = str.Remove(str.Length);

            return str;
        }
    }
}
