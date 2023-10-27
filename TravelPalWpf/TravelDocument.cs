namespace TravelPalWpf
{
    public class TravelDocument : PackingListItem
    {
        public string Name { get; set; } // property namn 
        public bool Required { get; set; }


        //konstruktor som sätter properties
        public TravelDocument(string name, bool required)
        {
            Name = name;
            Required = required;
        }


        //metod som retunerar en sträng med dokumentets namn och om det är required
        public string GetInfo()
        {
            return "Document name:" + Name + " required:" + Required;
        }
    }

}
