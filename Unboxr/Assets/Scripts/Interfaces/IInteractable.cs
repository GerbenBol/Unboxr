﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

interface IInteractable
{
    public GameObject MyObject { get; }

    public void Interact();
}
