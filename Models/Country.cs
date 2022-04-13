using System;
using System.Collections.Generic;
using System.Text;

namespace palota_func_countries_assessment.Models { 
    public class Afr
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Eng
{
    public string official { get; set; }
    public string common { get; set; }
    public string f { get; set; }
    public string m { get; set; }
}

public class Nbl
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Nso
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Sot
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Ssw
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Tsn
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Tso
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Ven
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Xho
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Zul
{
    public string official { get; set; }
    public string common { get; set; }
}

public class NativeName
{
    public Afr afr { get; set; }
    public Eng eng { get; set; }
    public Nbl nbl { get; set; }
    public Nso nso { get; set; }
    public Sot sot { get; set; }
    public Ssw ssw { get; set; }
    public Tsn tsn { get; set; }
    public Tso tso { get; set; }
    public Ven ven { get; set; }
    public Xho xho { get; set; }
    public Zul zul { get; set; }
}

public class Name
{
    public string common { get; set; }
    public string official { get; set; }
    public NativeName nativeName { get; set; }
}

public class ZAR
{
    public string name { get; set; }
    public string symbol { get; set; }
}

public class Currencies
{
    public ZAR ZAR { get; set; }
}

public class Idd
{
    public string root { get; set; }
    public List<string> suffixes { get; set; }
}

public class Languages
{
    public string afr { get; set; }
    public string eng { get; set; }
    public string nbl { get; set; }
    public string nso { get; set; }
    public string sot { get; set; }
    public string ssw { get; set; }
    public string tsn { get; set; }
    public string tso { get; set; }
    public string ven { get; set; }
    public string xho { get; set; }
    public string zul { get; set; }
}

public class Ara
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Ces
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Cym
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Deu
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Est
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Fin
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Fra
{
    public string official { get; set; }
    public string common { get; set; }
    public string f { get; set; }
    public string m { get; set; }
}

public class Hrv
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Hun
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Ita
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Jpn
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Kor
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Nld
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Per
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Pol
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Por
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Rus
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Slk
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Spa
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Swe
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Urd
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Zho
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Translations
{
    public Ara ara { get; set; }
    public Ces ces { get; set; }
    public Cym cym { get; set; }
    public Deu deu { get; set; }
    public Est est { get; set; }
    public Fin fin { get; set; }
    public Fra fra { get; set; }
    public Hrv hrv { get; set; }
    public Hun hun { get; set; }
    public Ita ita { get; set; }
    public Jpn jpn { get; set; }
    public Kor kor { get; set; }
    public Nld nld { get; set; }
    public Per per { get; set; }
    public Pol pol { get; set; }
    public Por por { get; set; }
    public Rus rus { get; set; }
    public Slk slk { get; set; }
    public Spa spa { get; set; }
    public Swe swe { get; set; }
    public Urd urd { get; set; }
    public Zho zho { get; set; }
}

public class Demonyms
{
    public Eng eng { get; set; }
    public Fra fra { get; set; }
}

public class Maps
{
    public string googleMaps { get; set; }
    public string openStreetMaps { get; set; }
}

public class Gini
{
    public double _2014 { get; set; }
}

public class Car
{
    public List<string> signs { get; set; }
    public string side { get; set; }
}

public class Flags
{
    public string png { get; set; }
    public string svg { get; set; }
}

public class CoatOfArms
{
    public string png { get; set; }
    public string svg { get; set; }
}

public class CapitalInfo
{
    public List<double> latlng { get; set; }
}

public class PostalCode
{
    public string format { get; set; }
    public string regex { get; set; }
}

public class Country
{
    public Name name { get; set; }
    public List<string> tld { get; set; }
    public string cca2 { get; set; }
    public string ccn3 { get; set; }
    public string cca3 { get; set; }
    public string cioc { get; set; }
    public bool independent { get; set; }
    public string status { get; set; }
    public bool unMember { get; set; }
    public Currencies currencies { get; set; }
    public Idd idd { get; set; }
    public List<string> capital { get; set; }
    public List<string> altSpellings { get; set; }
    public string region { get; set; }
    public string subregion { get; set; }
    public Languages languages { get; set; }
    public Translations translations { get; set; }
    public List<double> latlng { get; set; }
    public bool landlocked { get; set; }
    public List<string> borders { get; set; }
    public double area { get; set; }
    public Demonyms demonyms { get; set; }
    public string flag { get; set; }
    public Maps maps { get; set; }
    public int population { get; set; }
    public Gini gini { get; set; }
    public string fifa { get; set; }
    public Car car { get; set; }
    public List<string> timezones { get; set; }
    public List<string> continents { get; set; }
    public Flags flags { get; set; }
    public CoatOfArms coatOfArms { get; set; }
    public string startOfWeek { get; set; }
    public CapitalInfo capitalInfo { get; set; }
    public PostalCode postalCode { get; set; }
}


}
