namespace ISpan.Project_02_DessertStory.Admin.Models
{
    public class Tool
    {
        public int[] GetAgeToArr(List<int> num)
        {
            int[] ageGroupCounts = new int[6];
            foreach (var age in num)
            {
                if (age > 0 && age < 18)
                    ageGroupCounts[0]++;
                else if (age >= 18 && age <= 30)
                    ageGroupCounts[1]++;
                else if (age > 30 && age <= 40)
                    ageGroupCounts[2]++;
                else if (age > 40 && age <= 50)
                    ageGroupCounts[3]++;
                else if (age > 50 && age <= 60)
                    ageGroupCounts[4]++;
                else if (age > 60)
                    ageGroupCounts[5]++;
            }
            return ageGroupCounts;
        }
    }
}
