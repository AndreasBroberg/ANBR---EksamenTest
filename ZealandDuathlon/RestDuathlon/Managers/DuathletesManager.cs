using ZealandDuathlon;

namespace RestDuathlon.Managers
{
    public class DuathletesManager
    {
        private static int _nextId = 1;
        private static List<Duathlete> _duathletes = new List<Duathlete>()
        {
            new Duathlete{ Bib = _nextId++, Name = "Eddy Quick Feet", AgeGroup = 4, Bike = 7200, Run = 2100 },
            new Duathlete{ Bib = _nextId++, Name = "Heavy Peter", AgeGroup = 3, Bike = 7521, Run = 2190 },
            new Duathlete{ Bib = _nextId++, Name = "Big Mike", AgeGroup = 2, Bike = 7350, Run = 2390 },
            new Duathlete{ Bib = _nextId++, Name = "Fat Joey", AgeGroup = 4, Bike = 8256, Run = 2676 },
            new Duathlete{ Bib = _nextId++, Name = "Magic Thomson", AgeGroup = 1, Bike = 6475, Run = 2025 }
        };

        public Duathlete Add(Duathlete newDuathlete)
        {
            newDuathlete.Bib = _nextId++;
            _duathletes.Add(newDuathlete);
            return newDuathlete;
        }

        public List<Duathlete> GetAll()
        {
            return new List<Duathlete>(_duathletes);
        }

        public Duathlete GetById(int id)
        {
            Duathlete duathlete;
            duathlete = _duathletes.Find(x => x.Bib == id);
            if(duathlete != null) return duathlete;
            return null;
        }

        //public Duathlete Update(Duathlete newDuathlete, int bib)
        //{
        //    Duathlete duathleteToBeUpdated = GetById(bib);
        //    if (duathleteToBeUpdated == null) return null;
        //    duathleteToBeUpdated.Name = newDuathlete.Name;
        //    duathleteToBeUpdated.AgeGroup = newDuathlete.AgeGroup;
        //    duathleteToBeUpdated.Bike = newDuathlete.Bike;
        //    duathleteToBeUpdated.Run = newDuathlete.Run;
        //    return duathleteToBeUpdated;
        //}

        public Duathlete Delete(int id)
        {
            Duathlete duathleteTobeDeleted = GetById(id);
            if (duathleteTobeDeleted == null) return null;
            _duathletes.Remove(duathleteTobeDeleted);
            return duathleteTobeDeleted;
        }
    }
}
