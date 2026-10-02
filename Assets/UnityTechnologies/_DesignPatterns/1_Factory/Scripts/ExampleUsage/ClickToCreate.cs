using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DesignPatterns.Factory
{
    public class ClickToCreate : MonoBehaviour
    {
        [SerializeField] 
        private LayerMask m_LayerToClick;

        [SerializeField] 
        private Vector3 m_Offset;

        [SerializeField] 
        private Factory[] m_Factories;

        // Danh sách theo dõi tất cả product đã tạo
        private List<GameObject> m_CreatedProducts = new List<GameObject>();

        private void Update()
        {
            GetProductAtClick();
        }

        private void GetProductAtClick()
        {
            // Kiểm tra xem chuột trái có được nhấn không
            if (Input.GetMouseButtonDown(0))
            {
                // Lấy ngẫu nhiên một Factory từ danh sách
                Factory selectedFactory = m_Factories[Random.Range(0, m_Factories.Length)];
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                // Kiểm tra raycast có trúng collider trên layer cần click không
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, m_LayerToClick) && selectedFactory != null)
                {
                    IProduct product = selectedFactory.GetProduct(hitInfo.point + m_Offset);
                    
                    // Thêm GameObject của product vừa tạo vào danh sách
                    if (product is Component component) 
                    {
                        m_CreatedProducts.Add(component.gameObject);
                    }
                }
            }
        }
        
        private void OnDestroy()
        {
            foreach (GameObject product in m_CreatedProducts)
            {
                Destroy(product);
            }
            // Xóa danh sách khi object bị hủy
            m_CreatedProducts.Clear(); 
        }
    }
}

