﻿using System;
using System.Linq;


namespace _321_Khitrinovich_2UPDEMO_Method
{
    internal class Method
    {
        private ProductType _currentProductType = new ProductType();
        private MaterialType _currentMaterialType = new MaterialType();
        public int CalculateMaterial(int productTypeId,
                   int materialTypeId,
                   int productCount,
                   double parameter1,
                   double parameter2)
            {
                if (productTypeId <= 0 || materialTypeId <= 0 || productCount <= 0 || parameter1 <= 0 || parameter2 <= 0)
                {
                    return -1;
                }
                var productType = getProductType(productTypeId);
                if (productType == null)
                {
                    return -1;
                }
                var materialType = getMaterialType(materialTypeId);
                if (materialType == null)
                {
                    return -1;
                }
                try
                {
                    double materialPerUnit = parameter1 * parameter2 * Convert.ToDouble(productType.KoеffType);
                    double totalMaterial = materialPerUnit * productCount;
                    double defectMultiplier = (double)(1 + (materialType.BrokenMaterial / 100));
                    totalMaterial *= defectMultiplier;
                    return (int)Math.Ceiling(totalMaterial);
                }
                catch
                {
                    return -1;
                }
            }

            private ProductType getProductType(int id)
            {
                using (var context = new Entities())
                {
                    return context.ProductType.FirstOrDefault(ch => ch.ID == id);
                }
            }

            private MaterialType getMaterialType(int id)
            {
                using (var context = new Entities())
                {
                    return context.MaterialType.FirstOrDefault(ch => ch.ID == id);
                }
            }
        }
    }

