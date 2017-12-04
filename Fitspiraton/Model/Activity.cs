namespace Fitspiraton.Model
{
    class Activity
    {
        private string _type;
        private int _maxNumOfMembers;
        private string _nameOfTeacher;
        private string _description;
        private string _imgSource;

        public Activity(string type, int maxNumOfMembers, string nameOfTeacher, string description, string imgSource)
        {
            _type = type;
            _maxNumOfMembers = maxNumOfMembers;
            _nameOfTeacher = nameOfTeacher;
            _description = description;
            _imgSource = imgSource;
        }

        public Activity()
        {

        }

        public string Type { get => _type; set => _type = value; }
        public int MaxNumOfMembers { get => _maxNumOfMembers; set => _maxNumOfMembers = value; }
        public string NameOfTeacher { get => _nameOfTeacher; set => _nameOfTeacher = value; }
        public string Description { get => _description; set => _description = value; }
        public string ImgSource { get => _imgSource; set => _imgSource = value; }
    }
}
