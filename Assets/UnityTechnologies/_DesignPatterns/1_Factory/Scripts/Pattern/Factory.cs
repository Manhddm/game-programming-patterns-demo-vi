using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    /// <summary>
    /// Lớp cơ sở cho mọi loại Factory. Các Factory tạo instance của product.
    /// </summary>
    public abstract class Factory : MonoBehaviour
    {
        // Phương thức abstract để lấy một instance của product.
        public abstract IProduct GetProduct(Vector3 position);

        // Phương thức dùng chung cho tất cả Factory.
        public string GetLog(IProduct product)
        {
            string logMessage = "Factory: created product " + product.ProductName;
            return logMessage;
        }
    }
}