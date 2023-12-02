namespace hw3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder1 = new Builder1();
            director.Builder = builder1;
            director.Build();
            Console.WriteLine(builder1.GetProduct().DisplayParts());

            var builder2 = new Builder2();
            director.Builder = builder2;
            director.Build();
            Console.WriteLine(builder2.GetProduct().DisplayParts());

            var builder3 = new Builder3();
            director.Builder = builder3;
            director.Build();
            Console.WriteLine(builder3.GetProduct().DisplayParts());

            var builder4 = new Builder4();
            director.Builder = builder4;
            director.Build();
            Console.WriteLine(builder4.GetProduct().DisplayParts());
        }
    }

    public interface IBuilder
    {
        void BuildPartOne();
        void BuildPartTwo();
        void BuildPartThree();
    }

    public class Product
    {
        private List<object> parts = new List<object>();

        public void AddPart(string part)
        {
            parts.Add(part);
        }

        public string DisplayParts() => string.Join(", ", parts.ToArray());
    }

    public class Builder : IBuilder
    {
        protected Product product = new Product();
        public Builder()
        {
            this.product = new Product();
        }

        public void BuildPartOne()
        {
            product.AddPart("PartOne");
        }


        public void BuildPartTwo()
        {
            product.AddPart("PartTwo");
        }
        public virtual void BuildPartThree()
        {
            product.AddPart("PartThree");
        }

        public Product GetProduct()
        {
            Product output = product;
            product = new Product();
            return output;
        }
    }

    public class Builder1: Builder
    {
        public override void BuildPartThree()
        {
            product.AddPart("Garage");
        }
    }
    public class Builder2 : Builder
    {
        public override void BuildPartThree()
        {
            product.AddPart("Swimming Pool");
        }
    }
    public class Builder3 : Builder
    {
        public override void BuildPartThree()
        {
            product.AddPart("Fancy Statues");
        }
    }
    public class Builder4 : Builder
    {
        public override void BuildPartThree()
        {
            product.AddPart("Garden");
        }
    }


    public class Director
    {
        private IBuilder builder;
        public IBuilder Builder { set { builder = value; } }
        public void Build()
        {
            this.builder.BuildPartOne();
            this.builder.BuildPartTwo();
            this.builder.BuildPartThree();
        }
    }
}
