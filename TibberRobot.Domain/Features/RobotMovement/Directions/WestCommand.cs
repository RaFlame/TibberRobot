﻿using TibberRobot.Domain.Resources;

namespace TibberRobot.Domain.Features.RobotMovement.Directions
{
    public class WestCommand : CommandValidtor, ICommand
    {
        public decimal Limit { get; set; }

        public PositionResource GetNewPoint(decimal x, decimal y)
        {
            if (isValidCommand(x, Limit, false))
            {
                return new PositionResource(x - 1, y);
            }
            return null;
        }
    }
}
