namespace Packt.Shared

{

    public partial class Person
    {

        public string Origin
        {
            get
            {
                return "ORIGIN";
            }
            set
            {
                Name = value;
            }
        }

        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }

        }

    }

}