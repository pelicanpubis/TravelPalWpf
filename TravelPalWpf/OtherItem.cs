namespace TravelPalWpf
{

    //klass som implementerar interface från PackingListItem
    public class OtherItem : PackingListItem
    {

        //properties
        public string Name { get; set; } //namn på item

        //constructor som sätter properties
        public OtherItem(string name)
        {
            Name = name;
        }


        //metod som´förmodligen ska retunera en sträng med namnet på item.
        public string GetInfo()
        {
            return $"Item name: {Name}";
        }
    }

}
