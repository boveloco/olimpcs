using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

interface State
{

    void enter();

    void update();

    void exit();

}

