using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class DeliveryState
    {
        /// <summary>
        /// 未配達
        /// </summary>
        public const int UnDelivered = 0;
        /// <summary>
        /// 配達中
        /// </summary>
        public const int InDelivery = 1;
        /// <summary>
        /// 配達完了
        /// </summary>
        public const int Completion = 2;
    }
}
