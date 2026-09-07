namespace UzdevumuParvaldnieksKlases
{
    public class Uzdevums
    {
        //private, protected, internal, public
        private int _ID;

        public String Nosaukums { get; set; }

       // public int ID { get {  return _ID; } }
        public int ID => _ID;

        private string _apraksts;

        public string Apraksts
        {
            get { return _apraksts; }
            set { 
                if (value != null && value.Length > 5) 
                {
                    _apraksts = value; 
                }
            }
        }

        public Uzdevums() { }

        public Uzdevums(int id, string nosaukums, string apraksts)
        {
            _ID = id;
            Nosaukums = nosaukums;
            Apraksts = apraksts;
        }

        public override string ToString() { return $"ID: {_ID}, Nosaukums: {Nosaukums}, Apraksts: {Apraksts}"; }

      
    }
}
