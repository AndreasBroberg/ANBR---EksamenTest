namespace ZealandDuathlon
{
    public class Duathlete
    {
        public int Bib { get; set; }
        public string Name { get; set; }
        public int AgeGroup { get; set; }
        public int Bike { get; set; }
        public int Run { get; set; }
        public int Total
        {
            get
            {
                return Bike + Run;
            }
        }

        public void ValidateName()
        {
            if (String.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException("Navnet må ikke være tomt");
            if (Name.Length <= 3) throw new ArgumentOutOfRangeException("Name må minimum være 4 karakter langt" + Name);
        }

        public void ValidateAgeGroup()
        {
            if (AgeGroup == null) throw new ArgumentNullException("AgeGroup må ikke være tomt");
            if (AgeGroup <= 0 || AgeGroup >= 5) throw new ArgumentOutOfRangeException("AgeGroup skal være mellem 1-4" + AgeGroup);
        }

        public void Validate()
        {
            ValidateName();
            ValidateAgeGroup();
        }

        public override string ToString()
        {
            return $"{{{nameof(Bib)}={Bib.ToString()}, {nameof(Name)}={Name}, {nameof(AgeGroup)}={AgeGroup.ToString()}, {nameof(Bike)}={Bike.ToString()}, {nameof(Run)}={Run.ToString()}, {nameof(Total)}={Total.ToString()}}}";
        }
    }
}