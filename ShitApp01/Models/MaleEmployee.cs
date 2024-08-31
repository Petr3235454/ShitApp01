namespace ShitApp01.Models
{
    public class MaleEmployee : Employee 
    {
        public string DickLength { get; set; }

        public MaleEmployee(string name, string firstName, string lastName, int salary, string gender, string dickLength)
            : base(name, firstName, lastName, salary, gender)  
        {
            DickLength = dickLength; 
        }
    }
}