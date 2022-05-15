﻿using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EU4_Target_Selector.Models
{
    public enum ProvinceType { Null, Inlandsea, Lake, Land, Opensea, Sea, Wasteland }
    public enum Continent { Null, Europe, Africa, Asia, NorthAmerica, SouthAmerica, Oceania }
    public enum SuperRegionType { Null, WesternEurope, EasternEurope, Levant, NorthernAfrica, Persia, Tartary, CentralAmerica, Amazonia, India, EastIndies, China, FarEast, Andes, SouthernAfrica, NorthAmerica, Oceania, NorthAtlantic, MediterraneanSea, WesternIndianOcean, IndianOcean, WestPacific, EastPacific, EastAtlantic, WestAtlantic }
    public enum RegionType { Null, Scandinavia, NorthGermany, Russia, Baltic, SouthGermany, France, LowCountries, Italy, Balkans, Carpathia, Anatolia, Iberia, Britain, Poland, Ruthenia, PonticSteppe, Ural, Maghreb, Egypt, Mashriq, Arabia, Persia, Caucasia, Khorasan, CentralAsia, WestSiberia, Caribbeans, Colombia, WesternIndia, Hindustan, Deccan, Coromandel, Bengal, Tibet, Burma, Malaya, Indochina, Indonesia, Moluccas, Xinan, SouthChina, NorthChina, Mongolia, Manchuria, Korea, Brazil, LaPlata, Sahel, UpperPeru, EastAfrica, SouthAfrica, Congo, Peru, CentralAmerica, Mexico, RioGrande, California, Cascadia, GreatPlains, Mississippi, GreatLakes, Southeast, Northeast, Canada, HudsonBay, Japan, EastSiberia, Australia, Guinea, Oceania, Niger, HornofAfrica, BalticSea, NorthAtlantic, CentralAfrica, Mediterranean, ArabianSea, EasternIndianOcean, SouthChinaSea, EastChinaSea, SouthWestPacific, SouthIndianOcean, NorthWestPacific, NorthEastPacific, WesternIndianOcean, SouthAtlantic, WestAfricanSea, AmericanEastCoast, CaribbeanSea, AtlanticSouthAmerica, PacificSouthAmerica, SouthEastPacific }
    public enum AreaType { Null, ÖstraSvealand, ÖstraGötaland, VästraSvealand, Skåneland, VästraGötaland, Norrland, Trøndelag, Denmark, SchleswigHolstein, NorthJutland, Østlandet, Ostrobothnia, Vestlandet, Finland, SouthKarelia, NorthKarelia, Curonia, Estonia, Livonia, EastPrussia, WestPrussia, LowerSaxony, Mecklenburg, Vorpommern, Hinterpommern, Neumark, Mittelmark, SaxonyAnhalt, Weser, NorthWestphalia, Braunschweig, Saxony, Lusatia, Thuringia, LowerBavaria, UpperBavaria, UpperFranconia, EastSwabia, WestSwabia, LowerFranconia, Baden, Tirol, Alsace, EastBavaria, Palatinate, Hesse, LowerRhineland, SouthWestphalia, NorthRhine, Picardy, Flanders, Wallonia, SouthBrabant, NorthBrabant, Holland, Frisia, Liguria, Piedmont, Lombardy, EmiliaRomagna, PoValley, Venetia, Tuscany, LazioUmbria, MarcheAbruzzo, Campania, Apulia, Calabria, EasternSicily, WesternSicily, WesternMediterraneanIslands, InnerAustria, Carniola, Croatia, AustriaProper, Transdanubia, Dalmatia, Rascia, Bosnia, Serbia, NorthernGreece, Albania, Morea, Macedonia, Thrace, Bulgaria, Slavonia, Slovakia, Alföld, SouthernTransylvania, NorthernTransylvania, Silistria, Wallachia, AegeanArchipelago, Romandie, Switzerland, Normandy, Brittany, Gascony, Guyenne, LoireValley, Orléanais, Poitou, Champagne, ÎledeFrance, Lorraine, Auvergne, WesternBurgundy, EasternBurgundy, Languedoc, Catalonia, Provence, Savoy, Galicia, Asturias, Leon, Vasconia, Aragon, Castille, Extremadura, Toledo, Valencia, UpperAndalucia, LowerAndalucia, Alentejo, Beiras, Wessex, London, EastAnglia, WestMidlands, Wales, EastMidlands, NorthernEngland, Yorkshire, Lowlands, Highlands, TheIsles, Wielkopolska, Mazovia, CentralPoland, Sandomierz, RedRuthenia, Malopolska, Silesia, Moravia, Bohemia, Erzgebirge, Moldavia, Podlasie, Samogitia, Aukstaitija, Pskov, Minsk, Pripyat, Volhynia, WestDniepr, Podolia, Yedisan, Zaporizhia, Crimea, Azov, LowerDon, Chernigov, EastDniepr, SlobodaUkraine, WhiteRuthenia, Smolensk, Tver, Moscow, Oka, Ryazan, Tambov, Saratov, Kama, Galich, Vladimir, Yaroslavl, Novgorod, Beloozero, Pomorye, Vologda, Laponia, Hüdavendigar, Aydin, Çukurova, Germiyan, Karaman, Karadeniz, Ankara, Rum, Erzurum, Dulkadir, Baleares, NorthMorocco, Algiers, BarbaryCoast, Kabylia, Tunisia, Gharb, CentralMorocco, Tafilalt, SouthernMorocco, Sus, OuledNail, NorthSahara, Djerba, Tripolitania, Cyrenaica, Delta, Vostani, Said, Bahari, Palestine, RedSeaHills, Macaronesia, NorthAtlanticIslands, Ulster, Leinster, Connacht, Aleppo, Syria, Transjordan, Tabuk, Medina, Mecca, Asir, TihamaalYemen, LowerYemen, Hadramut, UpperYemen, alQasim, AnNafud, Bahrain, PirateCoast, Muscat, Dhofar, Mahra, Oman, SyrianDesert, IraqArabi, AlJazira, Basra, Khuzestan, Luristan, Shahrizor, Tabriz, Tabarestan, Kurdistan, Armenia, Shirvan, Imereti, KartliKakheti, Dagestan, IraqeAjam, Isfahan, GulfCoast, Mogostan, Kerman, Makran, Sistan, Birjand, Transcaspia, Khiva, Transoxiana, Merv, Herat, Ghor, Kabulistan, Balkh, Kyzylkum, SyrDarya, Arys, Ferghana, Jetysuu, Circassia, Astrakhan, Nogai, LowerYik, Samara, Bashkiria, Kazakhstan, Balchash, Aqmola, Ob, GreaterAntilles, LucayanArchipelago, WestCuba, EastCuba, Haiti, Dominica, LeewardIslands, WindwardIslands, Guyana, Patan, SouthernSindh, NorthernSindh, Multan, Lahore, Kashmir, HimalayanHills, Sirhind, Jangladesh, Marwar, Saurashtra, Ahmedabad, Tapti, Mewar, Jaipur, UpperDoab, Oudh, LowerDoab, Gird, Malwa, Khandesh, Konkan, Kanara, RaichurDoab, Mysore, Malabar, Madura, Kongu, SouthCarnatic, Rayalaseema, SouthTelingana, Andhra, Ahmednagar, Berar, Garjat, Gondwana, Orissa, UpperMahanadi, BaisiRajya, Purvanchal, Nepal, Bihar, Bundelkhand, Jharkhand, WestBengal, NorthBengal, Gaur, EastBengal, Bhutan, Assam, Tripura, Rakhine, Maidan, NagaHills, SouthLanka, IndianOceanIslands, Kalat, Chindwin, UpperBurma, Kachin, ShanHills, CentralBurma, LowerBurma, Karenni, ChiangMai, NorthTenasserim, CentralTenasserim, NorthMalaya, Malacca, Johor, Malaya, CentralThailand, Sukhothai, Cambodia, Mekong, Champa, Champasak, Angkor, Annam, Vientiane, Khorat, SôngHông, LuangPrabang, Aceh, Riau, Batak, Lampung, Banten, WestJava, CentralJava, EastJava, Surabaya, LesserSundaIslands, Timor, Brunei, Sabah, Kutai, Banjar, Kalimantan, Makassar, SouthSulawesi, NorthSulawesi, Moluccas, SpiceIslands, Palawan, WestMindanao, Visayas, SouthernLuzon, NorthernLuzon, Jambi, YunGuiFrontier, YunGuiHinterland, Guangxi, WestGuangdong, EastGuangdong, Fujian, Jiangxi, Hunan, Chuannan, Tsang, U, Kham, Sichuan, Hubei, Zhejiang, SouthJiangsu, SouthAnhui, SouthHenan, NorthHenan, Shaanxi, Shandong, Shanxi, SouthHebei, EastGansu, Ordos, InnerMongolia, NorthHebei, Liaoning, Amdo, WestGansu, Shanshan, CentralAltishahr, SouthDzungaria, NorthDzungaria, TannuUriankhai, OuterMongolia, Kobdo, Uliastai, Gobi, Chahar, XilinGol, WestHeilongjiangord, Cicigar, CentralHeilongjiang, SouthIlinHala, SouthJilin, Hamgyeong, WesternKorea, EasternKorea, SouthernKorea, Taiwan, Kashgaria, Venezuela, UpperGuyana, Suriname, Amapá, GraoPara, Maranhao, Ceará, Piauí, Pernambuco, Bahia, Goias, Diamantina, RiodeJaneiro, MinasGerais, SaoPaulo, Guayra, BandaOriental, CentralSahara, Paraguay, Mesopotamia, BuenosAires, SouthernPampas, BahiáBlanca, Patagonia, SouthernChile, CentralChile, Neheunken, Mozambique, Natal, Chaco, Tucuman, NorthernChile, Jujuy, Potosí, Kongo, Beni, Antisuyu, Moxos, PeruanCoast, Kuntisuyu, Huanuco, Chimor, Cajamarca, Iquitos, Quito, ColombianAmazonas, Popayan, CordilleraOccidental, Bogota, Coquivacoa, Maracaibo, CapeofGoodHope, CentralLlanos, Panama, CostaRica, Nicaragua, Guatemala, Honduras, GuatemalaLowlands, Oaxaca, Campeche, WestYucatan, Mixteca, Huasteca, Puebla, TierraCaliente, Mexico, Guanajuato, Jalisco, Nayarit, Zacatecas, GranChichimeca, Tamaulipas, Durango, Coahuila, Sonora, Chihuahua, BajaCalifornia, Arizona, AltaCalifornia, CentralValley, NorthCalifornia, Oregon, ColumbiaRiver, PugetSound, ColoradoPlateau, Apacheria, NewMexico, LlanoEstacado, Texas, CoastalPrairie, TexasPlains, HighPlains, Kansas, SouthernPlains, Louisiana, Arkansas, Ozarks, UpperLouisiana, CentralPlains, Minnesota, Iowa, NorthDakota, SouthDakota, LakeSuperior, Wisconsin, Illinois, Tennessee, Mississippi, WestFlorida, Alabama, Florida, EastFlorida, Georgia, UpperGeorgia, SouthCarolina, SouthCarolinaPiedmont, Overmountain, NorthCarolina, WesternKentucky, Kentucky, Indiana, Michigan, Ohio, GreatValley, Virginia, Vandalia, Maryland, Alleghenies, Westsylvania, DelawareValley, Iroquoisia, HudsonValley, NewYork, Massachusetts, Connecticut, LakeChamplain, NewHampshire, EasternMaine, StraitsofGeorgia, HecateStrait, AlaskaPanhandle, WesternAlaska, Newfoundland, LowerAcadia, UpperAcadia, Québec, UpperCanada, Huronia, TroisRivieres, UpperOntario, Laurentia, LowerCanada, CoteNord, Labrador, JamesBay, Abitibi, HudsonBay, Manitoba, SouthernKyushu, NorthernKyushu, Sanyodo, Sanindo, Kinai, Hokuriku, Tohoku, EasternKanto, WesternKanto, EasternChubu, WesternChubu, Hokkaido, Sakhalin, Kamchatka, Kolyma, Sakha, Okhotsk, Yakutia, NorthIlinHala, EastHeilongjiangord, Buryatia, Tunguska, Irkutsk, CentralSiberia, Kara, Yrtesh, Ishim, Perm, Ural, Kazan, Perth, Tasmania, Princeland, Victoria, Illawara, NewSouthWales, Queensland, SouthAtlanticIslands, CapVerde, SaoTome, Angola, Mascarenes, Greenland, TeIkaaMauiHauauru, TeIkaaMauiWaho, TeWaipounamu, Jolof, FutaJallon, Tekrur, Guinea, Manding, Kong, Massina, WestAfricanCoast, WesternSahara, NigerBend, Jenne, UpperVolta, LowerVolta, AtacoraOueme, Dendi, LowerNiger, Benin, Katsina, Zazzau, GulfofGuinea, Kano, WestAzbin, Bornu, Kanem, AdamawaPlateau, KongoleseCoast, SouthAfricanPlateau, Quelimane, Zimbabwe, Butua, LowerZambezi, Sakalava, CentralSwahiliCoast, Mombasa, NorthernSwahiliCoast, Mogadishu, Majeerteen, Ogaden, Somaliland, Ifat, Shewa, CentralEthiopia, Aussa, Kurdufan, Sennar, Hadiya, Dongola, UpperNubia, Tigray, RedSeaCoast, alWahat, LowerNubia, WestMicronesia, Melanesia, PapuanPeninsula, NorthernPolynesia, EastMicronesia, Fiji, Polynesia, EasternPolynesia, VogelkopPeninsula, BalticSea, Kattegat, WhiteSea, NorwegianSea, NorthSea, EnglishChannel, Kenya, BayofBiscay, NorthAtlantic, CelticSea, WesternMediterranean, EasternMediterranean, BlackSea, RedSea, ArabianSea, PersianGulf, BayofBengal, AndamanSea, EasternIndianOcean, JavaSea, BandaArafura, CelebesSea, SouthChinaSea, EastChinaSea, SeaofJapan, SeaofOkhotsk, PhilipineSea, CoralSea, GreatAustralianBight, SouthIndianOcean, TasmanSea, EastPacific, BeringSea, SwahiliCoast, WesternIndianOcean, CapeofStorms, SkeletonCoast, GulfofGuineaSea, WestAfricanSea, DenmarkStrait, LabradorSea, HudsonBaySea, GulfofStLawrence, GulfStream, BahamaChannel, GulfofMexico, CaribbeanSea, SargassoSea, CoastofGuyana, CoastofBrazil, ArgentineSea, ChileanSea, SeaofGrau, GulfofPanama, PacificCoast, GulfofAlaska, SouthAtlantic, NorthPacific, PolynesianTriangle, SouthPacific, Suzdal, MadagascarHighlands, Badlands, Saskatchewan, Shikoku, NorthAnhui, Pyongan, Furdan, Kuyavia, Desh, Arkhangelsk, Khuttalan, InteriorPlateau, Alberta, Assiniboia, UpperMissouri, Maine, RedRiveroftheNorth, SnakeRiver, Tanjore, NorthTelingana, Mithila, Katehar, SindSagar, NorthCarnatic, Baghelkhand, NorthLanka, Ningguta, EasternMongolia, TurpanKumul, Ngari, NorthJiangsu, Chuanbei, Samtskhe, Azerbaijan, Farsistan, Mashhad, Baghena, EastAzbin, alYamamah, TayNguyen, Volga, Fezzan, HautesPlains, Pecos, SouthernIllinois, PiedmontPlateau, StJohnsValley, Athabasca, Michoacan, Guerrero, Veracruz, EastYucatan, Chiapas, Minangkabau, EastMindanao, Pilbara, TopEnd, Capricornia, Kaffa, Damot, Ajuuraan, Jubba, EasternLlanos, WesternLlanos, Ucayali, UpperPeru, Cuyo, RioGrandedoSul, PatagonianAndes, Ofaie, SaoFrancisco, MatoGrosso, Amazon, Guapore, Pontal, Matamba, Betsimasaraka, SouthernMadagascar, Makuana, Ruvuma, Shire, Ngonde, UpperZambezi, Tanzania, Buzinza, Uganda, Bunyoro, Rwanda, Buha, LowerKasai, Kasai, Sankuru, Chokwe, Luba, Shaba, Zambia, Munster, Transvaal, Brisbane, OttawaValley }

    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class OldProvince
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [FieldNullValue(typeof(ProvinceType), "Null")]
        [FieldConverter(typeof(EnumConverter<ProvinceType>))]
        public ProvinceType Type { get; set; }
        [FieldNullValue(typeof(Continent), "Null")]
        [FieldConverter(typeof(EnumConverter<Continent>))]
        public Continent Continent { get; set; }
        [FieldNullValue(typeof(SuperRegionType), "Null")]
        [FieldConverter(typeof(EnumConverter<SuperRegionType>))]
        public SuperRegionType SuperRegion { get; set; }
        [FieldNullValue(typeof(RegionType), "Null")]
        [FieldConverter(typeof(EnumConverter<RegionType>))]
        public RegionType Region { get; set; }
        [FieldNullValue(typeof(AreaType), "Null")]
        [FieldConverter(typeof(EnumConverter<AreaType>))]
        public AreaType Area { get; set; }

        public static List<OldProvince> Provinces = new List<OldProvince>();
        public static void LoadProvinces(string path)
        {
            var engine = new FileHelperEngine<OldProvince>();
            engine.Encoding = Encoding.UTF8;
            Provinces = engine.ReadFileAsList(path);
        }
    }

    public class EnumConverter<T> : ConverterBase
    {
        private static readonly Regex Whitespace = new Regex(@"\s+");
        private static readonly Regex OtherSymbols = new Regex(@"(-|'|&)+");
        public override object StringToField(string from)
        {
            var temp = Whitespace.Replace(from, "");
            temp = OtherSymbols.Replace(temp, "");
            var enumType = typeof(T);
            return Enum.Parse(enumType, temp);
        }
    }
}
