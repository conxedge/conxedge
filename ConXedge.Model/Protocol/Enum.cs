using System;
using System.Collections.Generic;
using System.Text;

namespace ConXedge.Model.Protocol
{
    /// <summary>
    /// 通讯状态
    /// </summary>
    public enum CommState : byte
    {
        UP = 0,
        SUSPECT = 1,
        DOWN = 2,
        SUSPENDED = 3
    }

    /// <summary>
    /// 电量等级
    /// </summary>
    public enum BatteryLevel : byte
    {
        NO_BATTERY = 0,
        DEPLETED = 1,
        VERY_FLAT = 2,
        FLAT = 3,
        ZERO_PERCENT = 4,
        TEN_PERCENT = 5,
        TWENTY_PERCENT = 6,
        THIRTY_PERCENT = 7,
        FOURTY_PERCENT = 8,
        FIFTY_PERCENT = 9,
        SIXTY_PERCENT = 10,
        SEVENTY_PERCENT = 11,
        EIGHTY_PERCENT = 12,
        NINETY_PERCENT = 13,
        ONE_HUNDRED_PERCENT = 14,
        UNKNOWN = 15
    }

    /// <summary>
    /// 报警状态
    /// </summary>
    public enum AlarmStatus : byte
    {
        WARNING = 0,
        ALARM = 1,
        UNACKED = 2
    }

    /// <summary>
    /// 阈状态
    /// </summary>
    public enum ThresholdState : byte
    {
        LOW_CRITICAL = 0,
        LOW_ALARM = 1,
        IN_RANGE = 2,
        HIGH_ALARM = 3,
        HIGH_CRITICAL = 4
    }

    public enum EventType : byte
    {
        LOG_ERROR = 0,
        LOG_DISCONTINUITY = 1,
        LOG_PURGED = 2,
        LOG_CORRUPTION=3,
        PROCESSOR_RESET=4,
        BATTERY_LEVEL=5,
        LOW_BATTERY=6,
        NO_MAINS_POWER=7,
        SENSOR_CONNECTED=8,
        SENSOR_DISCONNECTED=9,
        SENSOR_ERROR=10,
        SENSOR_LOW_ALARM=11,
        SENSOR_HIGH_ALARM=12,
        SENSOR_LOW_CRITICAL=13,
        SENSOR_HIGH_CRITICAL=14,
        DIGITAL_INPUT=15,
        USER_LOGIN=16,
        CLOCK_CHANGE=17,
        COMM=18,
        FIRMWARE_VERSION=19,
        BATTERY_CHARGER=20,
        SENSOR_STARTED =22 
    }
}
