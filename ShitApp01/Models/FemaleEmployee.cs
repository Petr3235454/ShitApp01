namespace ShitApp01.Models
{
    public class FemaleEmployee : Employee 
    {
        public string BoobSize { get; set; }

        public FemaleEmployee(string name, string firstName, string lastName, int salary, string gender, string boobSize)
            : base(name, firstName, lastName, salary, gender)
        {
            BoobSize = boobSize;
        }
    }
}