using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Models
{
    interface ICourseState
    {
        void CourseState();
        void BasedAction();

    }
    //class CoursePaid : ICourseState
    //{
    //    public void BasedAction()
    //    {
    //       //paidAction 
    //    }

    //    public void CourseState()
    //    {
    //       //paidCourse
    //    }
    //}
    //class CourseFree : ICourseState
    //{
    //    public void BasedAction()
    //    {
    //        //FreeAction 
    //    }

    //    public void CourseState()
    //    {
    //        //FreeCourse
    //    }
    //}


}
