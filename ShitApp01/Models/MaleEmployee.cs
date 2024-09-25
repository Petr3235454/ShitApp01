namespace ShitApp01.Models
{
    public class MaleEmployee : Employee 
    {
        public int DickLength { get; set; }

        public MaleEmployee(string name, string firstName, string lastName, int salary, string gender, int dickLength)
            : base(name, firstName, lastName, salary, gender)  
        {
            DickLength = dickLength; 
        }
    }
}