namespace ACBMatchEventsAPI.Responses
{
    public class GetTeamLeadersResponse
    {
        public IEnumerable<long> HomeLeaders { get; set; }
        public IEnumerable<long> AwayLeaders { get; set;  }
    }
}
