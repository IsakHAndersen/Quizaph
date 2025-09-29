using Models.Enums;
using QuizaphFrontend.Models.Quizes;

namespace QuizaphFrontend.Services
{
    public static class StaticQuizDataRetrievalService
    {

        public static readonly Dictionary<QuizCategory, string> CategoryColorMap = new()
    {
        { QuizCategory.Geography, "#1976D2" },       // Blue - oceans, maps
        { QuizCategory.GeneralKnowledge, "#6fcaaa" },// Teal - versatile
        { QuizCategory.History, "#8B5E3C" },         // Brown - old books, parchment
        { QuizCategory.Technology, "#6029e7" },      // Purple - futuristic
        { QuizCategory.Sports, "#4f9ff3" },          // Sky blue - energy, action
        { QuizCategory.Science, "#00ACC1" },         // Cyan - lab, chemistry
        { QuizCategory.Literature, "#A1887F" },      // Warm brown - paper, books
        { QuizCategory.Art, "#E91E63" },             // Pink/magenta - creativity
        { QuizCategory.Entertainment, "#FF9800" },   // Orange - fun, playful
        { QuizCategory.Mathematics, "#9C27B0" },     // Deep purple - logic, formulas
        { QuizCategory.Language, "#009688" },        // Teal green - communication
        { QuizCategory.Philosophy, "#455A64" },      // Slate gray - thoughtful, deep
        { QuizCategory.Politics, "#D32F2F" },        // Red - debate, power
        { QuizCategory.Economics, "#388E3C" },       // Green - money, growth
        { QuizCategory.Music, "#7E57C2" },           // Soft purple - artistic, rhythm
        { QuizCategory.MoviesAndTV, "#F44336" },     // Red - cinema curtains
        { QuizCategory.Gaming, "#00C853" },          // Bright green - game consoles
        { QuizCategory.FoodAndDrink, "#FF7043" },    // Orange/red - appetizing
        { QuizCategory.Travel, "#5D4037" },          // Earthy brown - exploration
        { QuizCategory.Fashion, "#EC407A" },         // Pink - stylish, modern
        { QuizCategory.Mythology, "#6A1B9A" },       // Dark violet - mystical
        { QuizCategory.Religion, "#FFD600" },        // Gold/yellow - sacred
        { QuizCategory.Nature, "#388E3C" },          // Green - forests
        { QuizCategory.Medicine, "#0288D1" },        // Medical blue
        { QuizCategory.Astronomy, "#1A237E" },       // Deep blue/navy - night sky
        { QuizCategory.Business, "#2E7D32" },        // Corporate green
        { QuizCategory.Riddles, "#FFC107" },         // Amber - playful, puzzles
        { QuizCategory.CurrentEvents, "#F57C00" }    // Orange - news, urgency
    };
        public static CountryQuizData GetCountryQuizData()
        {
            return new CountryQuizData
            {
                Countries = new List<Country>
                {
                    new Country
                    {
                        CountryName = "Australia",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Australia", "Commonwealth of Australia" },
                        Id = "au",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Fiji",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Fiji", "Republic of Fiji", "Viti" },
                        Id = "fj",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Kiribati",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Kiribati", "Republic of Kiribati" },
                        Id = "ki",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Marshall Islands",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Marshall Islands", "Republic of the Marshall Islands", "M̧ajeļ" },
                        Id = "mh",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Micronesia",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Micronesia", "Federated States of Micronesia", "FSM" },
                        Id = "fm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Nauru",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Nauru", "Republic of Nauru" },
                        Id = "nr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "New Zealand",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "New Zealand", "Aotearoa", "NZ" },
                        Id = "nz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Palau",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Palau", "Republic of Palau", "Beluu er a Belau" },
                        Id = "pw",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Papua New Guinea",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Papua New Guinea", "Papa New Guinea", "Independent State of Papua New Guinea", "PNG" },
                        Id = "pg",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Samoa",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Samoa", "Independent State of Samoa", "Sāmoa" },
                        Id = "ws",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Solomon Islands",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Solomon Islands" },
                        Id = "sb",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Tonga",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Tonga", "Kingdom of Tonga", "Puleʻanga Fakatuʻi ʻo Tonga" },
                        Id = "to",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Tuvalu",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Tuvalu" },
                        Id = "tv",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Vanuatu",
                        Continent = Continent.Oceania,
                        ValidNames = new List<string> { "Vanuatu", "Republic of Vanuatu", "Ripablik blong Vanuatu" },
                        Id = "vu",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Afghanistan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Afghanistan", "Islamic Republic of Afghanistan", "افغانستان" },
                        Id = "af",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Armenia",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Armenia", "Republic of Armenia", "Հայաստան", "Hayastan" },
                        Id = "am",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Azerbaijan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Azerbaijan", "Republic of Azerbaijan", "Azərbaycan", "Azerbajan" },
                        Id = "az",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Bahrain",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Bahrain", "Kingdom of Bahrain", "البحرين‎" },
                        Id = "bh",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Bangladesh",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Bangladesh", "People's Republic of Bangladesh", "বাংলাদেশ" },
                        Id = "bd",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Bhutan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Bhutan", "Kingdom of Bhutan", "འབྲུག་ཡུལ་", "Druk Yul" },
                        Id = "bt",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Brunei",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Brunei", "Nation of Brunei", "Brunei Darussalam" },
                        Id = "bn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Cambodia",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Kingdom of Cambodia", "Kampuchea", "ព្រះរាជាណាចក្រ​កម្ពុជា", "Cambodia"},
                        Id = "kh",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "China",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "China", "People's Republic of China", "PRC", "中国", "Zhōngguó" },
                        Id = "cn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Cyprus",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Cyprus", "Republic of Cyprus", "Κύπρος", "Kıbrıs" },
                        Id = "cy",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Georgia",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Georgia", "Sakartvelo", "საქართველო" },
                        Id = "ge",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "India",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "India", "Republic of India", "भारत", "Bhārat" },
                        Id = "in",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Indonesia",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Indonesia", "Republic of Indonesia", "Republik Indonesia" },
                        Id = "id",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Iran",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Iran", "Islamic Republic of Iran", "ایران‎" },
                        Id = "ir",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Iraq",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Iraq", "Republic of Iraq", "العراق‎" },
                        Id = "iq",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Israel",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Israel", "State of Israel", "יִשְׂרָאֵל", "ישראל" },
                        Id = "il",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Japan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Japan", "Nippon", "Nihon", "日本" },
                        Id = "jp",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Jordan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Jordan", "Hashemite Kingdom of Jordan", "الأردن‎" },
                        Id = "jo",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Kazakhstan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Kazakhstan", "Republic of Kazakhstan", "Қазақстан", "kazakstan" },
                        Id = "kz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Kuwait",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Kuwait", "State of Kuwait", "دولة الكويت‎" },
                        Id = "kw",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Kyrgyzstan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Kyrgyzstan", "Kyrgyz Republic", "Кыргызстан", "kyrgystan" },
                        Id = "kg",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Laos",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Laos", "Lao People's Democratic Republic", "ສ.ປ.ປ.ລາວ", "Lao PDR" },
                        Id = "la",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Lebanon",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Lebanon", "Lebanese Republic", "الجمهورية اللبنانية‎" },
                        Id = "lb",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Malaysia",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Malaysia", "Federation of Malaysia" },
                        Id = "my",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Maldives",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Maldives", "Republic of Maldives", "Dhivehi Raajje" },
                        Id = "mv",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Mongolia",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Mongolia", "Монгол улс", "Mongol Uls" },
                        Id = "mn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Myanmar",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Myanmar", "Burma", "Republic of the Union of Myanmar", "မြန်မာ" },
                        Id = "mm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Nepal",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Nepal", "Federal Democratic Republic of Nepal", "नेपाल" },
                        Id = "np",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "North Korea",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "North Korea", "Democratic People's Republic of Korea", "DPRK", "조선", "조선민주주의인민공화국" },
                        Id = "kp",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Taiwan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Taiwan", "Republic of China", "ROC", "Taipei", "Chinese Taipei","Formosa" },
                        Id = "TW",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Oman",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Oman", "Sultanate of Oman", "سلطنة عمان‎" },
                        Id = "om",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Pakistan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Pakistan", "Islamic Republic of Pakistan", "پاکستان" },
                        Id = "pk",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Palestine",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Palestine", "State of Palestine", "فلسطين", "Palestina" },
                        Id = "ps",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Philippines",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Philippines", "Republic of the Philippines", "Pilipinas", "Philipines"},
                        Id = "ph",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Qatar",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Qatar", "State of Qatar", "دولة قطر‎" },
                        Id = "qa",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Saudi Arabia",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Saudi Arabia", "Kingdom of Saudi Arabia", "KSA", "المملكة العربية السعودية‎" },
                        Id = "sa",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Singapore",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Singapore", "Republic of Singapore", "Singapura", "新加坡" },
                        Id = "sg",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "South Korea",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "South Korea", "Republic of Korea", "ROK", "대한민국", "Hanguk" },
                        Id = "kr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Sri Lanka",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Sri Lanka", "Democratic Socialist Republic of Sri Lanka", "ශ්‍රී ලංකාව", "இலங்கை", "Ceylon" },
                        Id = "lk",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Syria",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Syria", "Syrian Arab Republic", "سوريا‎" },
                        Id = "sy",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Tajikistan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Tajikistan", "Republic of Tajikistan", "Тоҷикистон" },
                        Id = "tj",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Thailand",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Thailand", "Kingdom of Thailand", "ประเทศไทย", "Prathet Thai" },
                        Id = "th",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Timor-Leste",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Timor-Leste", "East Timor", "Democratic Republic of Timor-Leste" },
                        Id = "tl",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Turkey",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Turkey", "Republic of Turkey", "Türkiye" },
                        Id = "tr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Turkmenistan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Turkmenistan", "Türkmenistan" },
                        Id = "tm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "United Arab Emirates",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "United Arab Emirates", "UAE", "الإمارات العربية المتحدة‎" },
                        Id = "ae",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Uzbekistan",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Uzbekistan", "Republic of Uzbekistan", "Oʻzbekiston" },
                        Id = "uz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Vietnam",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Vietnam", "Socialist Republic of Vietnam", "Việt Nam" },
                        Id = "vn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Yemen",
                        Continent = Continent.Asia,
                        ValidNames = new List<string> { "Yemen", "Republic of Yemen", "اليمن‎" },
                        Id = "ye",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Albania",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Albania", "Republic of Albania", "Shqipëria" },
                        Id = "al",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Andorra",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Andorra", "Principality of Andorra" },
                        Id = "ad",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Austria",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Austria", "Republic of Austria", "Österreich" },
                        Id = "at",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Belarus",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Belarus", "Republic of Belarus", "Беларусь" },
                        Id = "by",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Belgium",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Belgium", "Kingdom of Belgium", "Belgique", "België" },
                        Id = "be",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Bosnia and Herzegovina",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Bosnia and Herzegovina", "Bosnia‑Herzegovina", "BiH", "Bosnia", "Herzegovina"},
                        Id = "ba",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Bulgaria",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Bulgaria", "Republic of Bulgaria", "България" },
                        Id = "bg",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Croatia",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Croatia", "Republic of Croatia", "Hrvatska" },
                        Id = "hr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Czech Republic",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Czech Republic", "Czechia", "Česká republika" },
                        Id = "cz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Denmark",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Denmark", "Kingdom of Denmark", "Danmark" },
                        Id = "dk",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Estonia",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Estonia", "Republic of Estonia", "Eesti" },
                        Id = "ee",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Finland",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Finland", "Republic of Finland", "Suomi" },
                        Id = "fi",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "France",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "France", "French Republic", "République française" },
                        Id = "fr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Germany",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Germany", "Federal Republic of Germany", "Deutschland" },
                        Id = "de",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Greece",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Greece", "Hellenic Republic", "Ελλάδα" },
                        Id = "gr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Hungary",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Hungary", "Magyarország" },
                        Id = "hu",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Iceland",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Iceland", "Republic of Iceland", "Ísland" },
                        Id = "is",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Ireland",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Ireland", "Éire", "Republic of Ireland" },
                        Id = "ie",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Italy",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Italy", "Italian Republic", "Italia" },
                        Id = "it",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Kosovo",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Kosovo", "Republic of Kosovo", "Kosova" },
                        Id = "xk",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Latvia",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Latvia", "Republic of Latvia", "Latvija" },
                        Id = "lv",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Liechtenstein",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Liechtenstein", "Principality of Liechtenstein" },
                        Id = "li",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Lithuania",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Lithuania", "Republic of Lithuania", "Lietuva" },
                        Id = "lt",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Luxembourg",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Luxembourg", "Grand Duchy of Luxembourg", "Luxemburg" },
                        Id = "lu",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Malta",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Malta", "Republic of Malta" },
                        Id = "mt",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Moldova",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Moldova", "Republic of Moldova" },
                        Id = "md",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Monaco",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Monaco", "Principality of Monaco" },
                        Id = "mc",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Montenegro",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Montenegro", "Crna Gora" },
                        Id = "me",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Netherlands",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Netherlands", "Kingdom of the Netherlands", "Nederland", "Holland" },
                        Id = "nl",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "North Macedonia",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "North Macedonia", "Republic of North Macedonia", "Macedonia", "Македонија" },
                        Id = "mk",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Norway",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Norway", "Kingdom of Norway", "Norge" },
                        Id = "no",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Poland",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Poland", "Republic of Poland", "Polska" },
                        Id = "pl",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Portugal",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Portugal", "Portuguese Republic" },
                        Id = "pt",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Romania",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Romania", "România" },
                        Id = "ro",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Russia",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Russia", "Russian Federation", "Российская Федерация", "Rossiya" },
                        Id = "ru",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "San Marino",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "San Marino", "Serenissima Republic of San Marino" },
                        Id = "sm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Serbia",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Serbia", "Republic of Serbia", "Srbija" },
                        Id = "rs",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Slovakia",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Slovakia", "Slovak Republic", "Slovensko" },
                        Id = "sk",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Slovenia",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Slovenia", "Republic of Slovenia", "Slovenija" },
                        Id = "si",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Spain",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Spain", "Kingdom of Spain", "España" },
                        Id = "es",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Sweden",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Sweden", "Kingdom of Sweden", "Sverige" },
                        Id = "se",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Switzerland",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Switzerland", "Swiss Confederation", "Schweiz", "Suisse", "Svizzera" },
                        Id = "ch",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Ukraine",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Ukraine", "Україна" },
                        Id = "ua",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "United Kingdom",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "United Kingdom", "UK", "Britain", "Great Britain", "England", "United Kingdom of Great Britain and Northern Ireland" },
                        Id = "gb",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Vatican City",
                        Continent = Continent.Europe,
                        ValidNames = new List<string> { "Vatican City", "Holy See", "Vatican", "Vatican City State" },
                        Id = "va",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Canada",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Canada", "CA" },
                        Id = "ca",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "United States",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "United States", "USA", "United States of America", "America", "US" },
                        Id = "us",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Mexico",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Mexico", "México", "United Mexican States", "Estados Unidos Mexicanos" },
                        Id = "mx",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Guatemala",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Guatemala", "Republic of Guatemala", "República de Guatemala" },
                        Id = "gt",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Belize",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Belize", "British Honduras" },
                        Id = "bz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Honduras",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Honduras", "Republic of Honduras", "República de Honduras" },
                        Id = "hn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "El Salvador",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "El Salvador", "Republic of El Salvador", "República de El Salvador" },
                        Id = "sv",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Nicaragua",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Nicaragua", "Republic of Nicaragua", "República de Nicaragua" },
                        Id = "ni",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Costa Rica",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Costa Rica", "Republic of Costa Rica", "República de Costa Rica" },
                        Id = "cr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Panama",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Panama", "Republic of Panama", "República de Panamá" },
                        Id = "pa",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Cuba",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Cuba", "Republic of Cuba", "República de Cuba" },
                        Id = "cu",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Haiti",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Haiti", "Republic of Haiti", "République d'Haïti", "Ayiti" },
                        Id = "ht",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Dominican Republic",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Dominican Republic", "República Dominicana" },
                        Id = "do",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Jamaica",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Jamaica", "JA" },
                        Id = "jm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Trinidad and Tobago",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Trinidad and Tobago", "Republic of Trinidad and Tobago", "Trinidad" },
                        Id = "tt",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Bahamas",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Bahamas", "Commonwealth of the Bahamas", "The Bahamas" },
                        Id = "bs",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Barbados",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Barbados", "BB" },
                        Id = "bb",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Saint Lucia",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Saint Lucia", "St. Lucia" },
                        Id = "lc",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Grenada",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Grenada", "GR", "Spice Island" },
                        Id = "gd",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Saint Vincent and the Grenadines",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Saint Vincent and the Grenadines", "St. Vincent", "Saint Vincent" },
                        Id = "vc",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Antigua and Barbuda",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Antigua and Barbuda", "Antigua", "Barbuda" },
                        Id = "ag",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Dominica",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Dominica", "Commonwealth of Dominica" },
                        Id = "dm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Saint Kitts and Nevis",
                        Continent = Continent.NorthAmerica,
                        ValidNames = new List<string> { "Saint Kitts and Nevis", "St. Kitts", "Saint Kitts", "Nevis", "Federation of Saint Christopher and Nevis" },
                        Id = "kn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Argentina",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Argentina", "Argentine Republic", "República Argentina" },
                        Id = "ar",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Bolivia",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Bolivia", "Plurinational State of Bolivia", "Estado Plurinacional de Bolivia" },
                        Id = "bo",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Brazil",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Brazil", "Brasil", "Federative Republic of Brazil", "República Federativa do Brasil" },
                        Id = "br",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Chile",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Chile", "Republic of Chile", "República de Chile" },
                        Id = "cl",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Colombia",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Colombia", "Republic of Colombia", "República de Colombia" },
                        Id = "co",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Ecuador",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Ecuador", "Republic of Ecuador", "República del Ecuador" },
                        Id = "ec",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Guyana",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Guyana", "Co-operative Republic of Guyana" },
                        Id = "gy",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Paraguay",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Paraguay", "Republic of Paraguay", "República del Paraguay" },
                        Id = "py",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Peru",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Peru", "Republic of Peru", "República del Perú" },
                        Id = "pe",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Suriname",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Suriname", "Republic of Suriname", "Surinam" },
                        Id = "sr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Uruguay",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Uruguay", "Oriental Republic of Uruguay", "República Oriental del Uruguay" },
                        Id = "uy",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Venezuela",
                        Continent = Continent.SouthAmerica,
                        ValidNames = new List<string> { "Venezuela", "Bolivarian Republic of Venezuela", "República Bolivariana de Venezuela" },
                        Id = "ve",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Algeria",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Algeria", "People's Democratic Republic of Algeria", "الجزائر" },
                        Id = "dz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Angola",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Angola", "Republic of Angola", "República de Angola" },
                        Id = "ao",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Benin",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Benin", "Republic of Benin", "Bénin", "République du Bénin" },
                        Id = "bj",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Botswana",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Botswana", "Republic of Botswana" },
                        Id = "bw",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Burkina Faso",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Burkina Faso", "Burkina" },
                        Id = "bf",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Burundi",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Burundi", "Republic of Burundi", "République du Burundi" },
                        Id = "bi",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Cape Verde",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Cabo Verde", "Cape Verde", "Republic of Cabo Verde" },
                        Id = "cv",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Cameroon",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Cameroon", "Republic of Cameroon", "République du Cameroun" },
                        Id = "cm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Central African Republic",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Central African Republic", "CAR", "République centrafricaine" },
                        Id = "cf",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Chad",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Chad", "Republic of Chad", "Tchad", "جمهورية تشاد" },
                        Id = "td",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Comoros",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Comoros", "Union of the Comoros", "جزر القمر", "Comores" },
                        Id = "km",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Democratic Republic of the Congo",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Democratic Republic of the Congo", "DR Congo", "Congo-Kinshasa", "République démocratique du Congo", "Republic of the Congo", "Congo" },
                        Id = "cd",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Côte d'Ivoire",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Côte d'Ivoire", "Ivory Coast", "Republic of Côte d'Ivoire" },
                        Id = "ci",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Djibouti",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Djibouti", "Republic of Djibouti", "جيبوتي" },
                        Id = "dj",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Egypt",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Egypt", "Arab Republic of Egypt", "مصر", "Misr" },
                        Id = "eg",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Equatorial Guinea",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Equatorial Guinea", "Republic of Equatorial Guinea", "Guinea Ecuatorial" },
                        Id = "gq",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Eritrea",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Eritrea", "State of Eritrea", "ኤርትራ", "إرتريا‎" },
                        Id = "er",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Eswatini",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Eswatini", "Swaziland", "Kingdom of Eswatini" },
                        Id = "sz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Ethiopia",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Ethiopia", "Federal Democratic Republic of Ethiopia", "ኢትዮጵያ" },
                        Id = "et",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Gabon",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Gabon", "Gabonese Republic", "République gabonaise" },
                        Id = "ga",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Gambia",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Gambia", "Republic of The Gambia", "The Gambia" },
                        Id = "gm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Ghana",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Ghana", "Republic of Ghana" },
                        Id = "gh",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Guinea",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Guinea", "Republic of Guinea", "Guinée" },
                        Id = "gn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Guinea-Bissau",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Guinea-Bissau", "Republic of Guinea-Bissau", "Guiné-Bissau" },
                        Id = "gw",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Kenya",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Kenya", "Republic of Kenya" },
                        Id = "ke",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Lesotho",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Lesotho", "Kingdom of Lesotho" },
                        Id = "ls",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Liberia",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Liberia", "Republic of Liberia" },
                        Id = "lr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Libya",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Libya", "State of Libya", "ليبيا‎" },
                        Id = "ly",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Madagascar",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Madagascar", "Republic of Madagascar", "Repoblikan’i Madagasikara" },
                        Id = "mg",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Malawi",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Malawi", "Republic of Malawi" },
                        Id = "mw",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Mali",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Mali", "Republic of Mali", "République du Mali" },
                        Id = "ml",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Mauritania",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Mauritania", "Islamic Republic of Mauritania", "موريتانيا" },
                        Id = "mr",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Mauritius",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Mauritius", "Republic of Mauritius", "Moris" },
                        Id = "mu",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Morocco",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Morocco", "Kingdom of Morocco", "المغرب", "Maroc" },
                        Id = "ma",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Mozambique",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Mozambique", "Republic of Mozambique", "Moçambique" },
                        Id = "mz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Namibia",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Namibia", "Republic of Namibia" },
                        Id = "na",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Niger",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Niger", "Republic of the Niger", "République du Niger" },
                        Id = "ne",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Nigeria",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Nigeria", "Federal Republic of Nigeria" },
                        Id = "ng",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Rwanda",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Rwanda", "Republic of Rwanda", "Repubulika y’u Rwanda" },
                        Id = "rw",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Sao Tome and Principe",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Sao Tome and Principe", "São Tomé and Príncipe", "Democratic Republic of São Tomé and Príncipe", "Sao Tome" },
                        Id = "st",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Senegal",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Senegal", "Republic of Senegal", "République du Sénégal" },
                        Id = "sn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Seychelles",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Seychelles", "Republic of Seychelles", "Sesel" },
                        Id = "sc",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Sierra Leone",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Sierra Leone", "Republic of Sierra Leone" },
                        Id = "sl",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Somalia",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Somalia", "Federal Republic of Somalia", "Soomaaliya", "الصومال‎" },
                        Id = "so",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "South Africa",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "South Africa", "Republic of South Africa", "RSA" },
                        Id = "za",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "South Sudan",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "South Sudan", "Republic of South Sudan" },
                        Id = "ss",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Sudan",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Sudan", "Republic of the Sudan", "السودان‎" },
                        Id = "sd",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Tanzania",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Tanzania", "United Republic of Tanzania" },
                        Id = "tz",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Togo",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Togo", "Togolese Republic", "République Togolaise" },
                        Id = "tg",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Tunisia",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Tunisia", "Republic of Tunisia", "تونس‎" },
                        Id = "tn",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Uganda",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Uganda", "Republic of Uganda" },
                        Id = "ug",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Zambia",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Zambia", "Republic of Zambia" },
                        Id = "zm",
                        Guessed = false
                    },
                    new Country
                    {
                        CountryName = "Zimbabwe",
                        Continent = Continent.Africa,
                        ValidNames = new List<string> { "Zimbabwe", "Republic of Zimbabwe" },
                        Id = "zw",
                        Guessed = false
                    },



                }
            };
        }
    }
}
