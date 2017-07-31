namespace mysql_tengxunyun
{
    /// <summary>
    /// COS对应 ： key：nba2k/user/<uid>,<regtime> value：<pwd>,<endtime>,<utime>,<sunum>,<unum>,<mcode>
    /// </summary>
    public class user
    {
        public string uid { get; set; }
        public string regtime { get; set; }
        public string pwd { get; set; }
        public string endtime { get; set; }
        public string utime { get; set; }
        public string sunum { get; set; }
        public string unum { get; set; }
        public string mcode { get; set; }
    }
    /// <summary>
    /// COS对应 ： key：nba2k/config/<uid> value：<txt>
    /// </summary>
    public class config
    {
        public string uid { get; set; }
        public string txt { get; set; }
    }
    /// <summary>
    /// COS对应 ： key：nba2k/log/<jtype>,<uid>,<jtime>,<num>,<msg> value：null
    /// </summary>
    public class log
    {
        public string type { get; set; }
        public string uid { get; set; }
        public string time { get; set; }
        public string num { get; set; }
        public string msg { get; set; }
    }
    /// <summary>
    /// COS对应 ： key：nba2k/cami/<ukey>,<uid>,<type>,<num>,<utime> value：del<0 or 1>,<regtime>,<reguid>
    /// </summary>
    public class cami
    {		
        public string key { get; set; }
        public string uid { get; set; }
        public string type { get; set; }
        public string num { get; set; }
        public string utime { get; set; }

    }
}
