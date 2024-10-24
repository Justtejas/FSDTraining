namespace LambdaDemo
{
    internal class Numbers
    {
       public static void Demo()
        {
            List<int> numbersList = new() { 10,22,33,44,52,65};
            var squaredNumbers = numbersList.Select(num => num *num);
            Console.WriteLine("----- Squared Numbers ------");
            foreach(var num in squaredNumbers)
            {
                Console.WriteLine(num);
            }

            List<int> evenNumbers = numbersList.FindAll(num => (num & 1) == 0);
            Console.WriteLine("----- Even Numbers ------");
            foreach(int num in evenNumbers)
            {
                Console.WriteLine(num);
            }
        }

    }
}
