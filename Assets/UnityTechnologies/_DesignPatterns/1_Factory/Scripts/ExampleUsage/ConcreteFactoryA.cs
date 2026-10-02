using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class ConcreteFactoryA : Factory
    {
        // Dùng để tạo prefab
        [SerializeField] 
        private ProductA m_ProductPrefab;

        public override IProduct GetProduct(Vector3 position)
        {
            // Tạo một instance từ prefab và lấy component product
            GameObject instance = Instantiate(m_ProductPrefab.gameObject, position, Quaternion.identity);
            ProductA newProduct = instance.GetComponent<ProductA>();

            // Mỗi product có logic riêng
            newProduct.Initialize();

            return newProduct;
        }
    }
}
