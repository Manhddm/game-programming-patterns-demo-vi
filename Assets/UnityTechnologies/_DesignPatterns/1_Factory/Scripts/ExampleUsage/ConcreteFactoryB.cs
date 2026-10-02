using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DesignPatterns.Factory
{
    public class ConcreteFactoryB : Factory
    {
        // Dùng để tạo prefab
        [SerializeField] 
        private ProductB m_ProductPrefab;

        public override IProduct GetProduct(Vector3 position)
        {
            // Tạo một instance từ prefab và lấy component product
            GameObject instance = Instantiate(m_ProductPrefab.gameObject, position, Quaternion.identity);
            ProductB newProduct = instance.GetComponent<ProductB>();

            // Mỗi product có logic riêng
            newProduct.Initialize();

            // Thêm hành vi riêng cho Factory này
            instance.name = newProduct.ProductName;
            Debug.Log(GetLog(newProduct));

            return newProduct;
        }
    }
}
