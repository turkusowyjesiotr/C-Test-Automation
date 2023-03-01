namespace DatabaseTest.Models
{
    public class TestTableModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string status_id { get; set; }
        public string method_name { get; set; }
        public string project_id { get; set; }
        public string session_id { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string env { get; set; }
        public string browser { get; set; }
        public string author_id { get; set; }

        public bool Equals(TestTableModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.name, name) && Equals(other.status_id, status_id)
                && Equals(other.method_name, method_name) && Equals(other.project_id, project_id) && Equals(other.session_id, session_id)
                && Equals(other.start_time, start_time) && Equals(other.end_time, end_time) && Equals(other.env, env)
                && Equals(other.browser, browser) && Equals(other.author_id, author_id);
        }
    }

}
