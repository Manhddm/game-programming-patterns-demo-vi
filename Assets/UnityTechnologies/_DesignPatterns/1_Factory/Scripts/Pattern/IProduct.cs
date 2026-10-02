using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    /// <summary>
    /// Interface dùng chung cho các product
    /// </summary>
    public interface IProduct
    {
        // Thêm property và method dùng chung tại đây
        public string ProductName { get; set; }

        // Tùy chỉnh phần này cho từng concrete product
        public void Initialize();
    }
}
