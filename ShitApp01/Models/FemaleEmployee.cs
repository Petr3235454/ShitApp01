namespace ShitApp01.Models
{
    public class FemaleEmployee : Employee 
    {
        public int BoobSize { get; set; }

        public FemaleEmployee(string name, string firstName, string lastName, int salary, string gender, int boobSize)
            : base(name, firstName, lastName, salary, gender)
        {
            BoobSize = boobSize;
        }
    }
}