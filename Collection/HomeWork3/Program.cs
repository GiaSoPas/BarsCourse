namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entity> entitiesList = new List<Entity>();
            
            entitiesList.Add(new Entity{ Id = 1, ParentId = 0, Name = "Root entity"});
            entitiesList.Add(new Entity{ Id = 2, ParentId = 1, Name = "Child of 1 entity"});
            entitiesList.Add(new Entity{ Id = 3, ParentId = 1, Name = "Child of 1 entity"});
            entitiesList.Add(new Entity{ Id = 4, ParentId = 2, Name = "Child of 2 entity"});
            entitiesList.Add(new Entity{ Id = 5, ParentId = 4, Name = "Child of 4 entity"});

            var dictionary = Do(entitiesList);
            // dictionary.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            
            foreach (KeyValuePair<int, List<Entity>> kvp in dictionary)
            {
                foreach (var entity in kvp.Value)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, entity.Id);
                }
                
            }
        }
        
        public static Dictionary<int, List<Entity>> Do(List<Entity> list)
        {
            var dictionary = new Dictionary<int, List<Entity>>();
            foreach (var entity in list)
            {
                dictionary.TryAdd(entity.ParentId, new List<Entity>());
                dictionary[entity.ParentId].Add(entity);
                
            }

            return dictionary;
        }

    }
    

    public class Entity
    {
        public int Id { get; set; }
        
        public int ParentId { get; set; }
        
        public string Name { get; set; }
    }

}