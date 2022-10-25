namespace ST2001681076
{
    /// <summary>
    /// The singleton class
    /// </summary>
    public sealed class RealEstateAgent
    {
        private static readonly Lazy<RealEstateAgent> _lazyRealEstateAgent = new Lazy<RealEstateAgent>(() => new RealEstateAgent());
        private List<Apartment> _apartments = new List<Apartment>();
        private string _name = "unset";

        public static RealEstateAgent Instance { get => _lazyRealEstateAgent.Value; }
        public List<Apartment> Apartments { get => _apartments; }
        public string Name { get => _name; set => _name = value; }

        private RealEstateAgent() { }

        public void AddApartment(Apartment apartment)
        {
            _apartments.Add(apartment);
        }

        public void AddApartments(List<Apartment> apartments)
        {
            _apartments.AddRange(apartments);
        }

        public bool RemoveApartment(string id)
        {
            return _apartments.RemoveAll((apartment) => apartment.Id == id) > 0;
        }

        public bool RemoveApartmentsById(List<string> ids)
        {
            return _apartments.RemoveAll((apartment) => ids.All((id) => id == apartment.Id)) > 0;
        }

        public void ShowApartments()
        {
            _apartments.ForEach((apartment) => Console.WriteLine(apartment));
        }
    }

    /// <summary>
    /// Class that represents an apartment
    /// </summary>
    public class Apartment
    {
        private string _id;
        private int _area;
        private int _price;
        private string _location;
        private bool _garage;
        private bool _furnished;

        public string Id { get => _id; }
        public int Area { get => _area; }
        public int Price { get => _price; }
        public string Location { get => _location; }
        public bool Garage { get => _garage; }
        public bool Furnished { get => _furnished; }

        public Apartment(string id, int area, int price, string location, bool garage, bool furnished)
        {
            _id = id;
            _area = area;
            _price = price;
            _location = location;
            _garage = garage;
            _furnished = furnished;
        }

        public override string ToString()
        {
            return
                $"Апартамент:\n" +
                $"Id: {Id}\n" +
                $"Площ: {Area}\n" +
                $"Цена: {Price}\n" +
                $"Адрес: {Location}\n" +
                $"Гараж: {BooleanToWord(Garage)}\n" +
                $"Обзаведен: {BooleanToWord(Furnished)}\n";
        }

        private String BooleanToWord(bool booleanToConvert)
        {
            return booleanToConvert ? "Да" : "Не";
        }
    }

    /// <summary>
    /// The main app entry point
    /// </summary>
    public class MainAppSingleton
    {
        public static void Main()
        {
            RealEstateAgent.Instance.AddApartment(new Apartment("a1", 120, 120_000, "bul. Ruski 36", true, true));
            RealEstateAgent.Instance.AddApartment(new Apartment("a2", 135, 70_000, "ul. Trakiya 140", false, true));
            RealEstateAgent.Instance.ShowApartments();

            Console.ReadKey();
        }
    }
}