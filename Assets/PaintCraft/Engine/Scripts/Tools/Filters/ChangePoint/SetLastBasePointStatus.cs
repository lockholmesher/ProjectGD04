﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeInspector;
using System;
using PaintCraft.Utils;

namespace PaintCraft.Tools.Filters.ChangePoint{
    [System.Flags]
    public enum PointState {
        FirstPoint      = 1<<0,
        MiddlePoints    = 1<<1,
        LastPoint       = 1<<2
    }

    /// <summary>
    /// Set interpolated point status
    /// </summary>
    [NodeMenuItemAttribute("ChangePoint/SetLastBasePointStatus")]
    public class SetLastBasePointStatus : FilterWithNextNode {
        public PointStatus PointStatus = PointStatus.ReadyToApply;

        [EnumFlags]
        public PointState PointState = PointState.FirstPoint | PointState.MiddlePoints | PointState.LastPoint;


        #region implemented abstract members of FilterWithNextNode
        public override bool FilterBody (BrushContext brushLineContext)
        {
            bool handleFirst = (brushLineContext.IsFirstPointInLine && ((PointState & PointState.FirstPoint) == PointState.FirstPoint));
            bool handleLast = (brushLineContext.IsLastPointInLine && ((PointState & PointState.LastPoint) == PointState.LastPoint));
            bool handleMiddle = (brushLineContext.IsFirstPointInLine == false && brushLineContext.IsLastPointInLine == false 
                && ((PointState & PointState.MiddlePoints) == PointState.MiddlePoints));
            
            if (handleFirst || handleLast || handleMiddle){
                LinkedListNode<Point> node = brushLineContext.BasePoints.Last;
                if (node != null){
                    node.Value.Status = PointStatus; 
                }               
            }
            return true;
        }
        #endregion
    }
}