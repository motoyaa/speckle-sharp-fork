﻿using System;
using System.Collections.Generic;
using System.Text;
using Objects.DefaultBuildingObjectKit.enums;
using Objects.DefaultBuildingObjectKit.ProjectOrganization;

namespace Objects.DefaultBuildingObjectKit.PhysicalObjects
{
  public class FlatSurface : CurveBasedElement
  {
  public flatSurfaceType Type{ get; set; }

  public double area { get; set; }

  public Level level { get; set; }
  public double thickness { get; set; }
    // to implement source app parameters interface from claire
  }
}
