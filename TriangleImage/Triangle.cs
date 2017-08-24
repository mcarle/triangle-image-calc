namespace TriangleImage{
    public class Triangle
    {
        public Triangle()
        {
            V1 = new TriangleVertex(); 
            V2 = new TriangleVertex(); 
            V3 = new TriangleVertex(); 
        }

        public TriangleVertex V1 {get; set;}

        public TriangleVertex V2 {get; set;}

        public TriangleVertex V3 {get; set;}

        public class TriangleVertex 
        {
            public int Row {get; set;}

            public int Col {get; set;}
        }
    }
}
