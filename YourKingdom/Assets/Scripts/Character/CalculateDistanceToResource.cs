using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.BuildingObject;

namespace Kingdom
{
    public class CalculateDistanceToResource
    {
        public List<Resource> CalculateDistance(List<Resource> listOfObjects, Building objects)
        {
            List<float> distance = new List<float>();
            List<Resource> resources = new List<Resource>();

            for (int i = 0; i < listOfObjects.Count; i++)
            {
                if (listOfObjects[i])
                {
                    distance.Add(Vector3.Distance(objects.transform.position, listOfObjects[i].transform.position));
                    resources.Add(listOfObjects[i]);
                }

            }

            QuickSort(distance, resources, 0, distance.Count - 1);

            return resources;
        }
        private void QuickSort(List<float> distance, List<Resource> resources, int left, int right)
        {
            if (right > left)
            {
                int pi = Partition(distance, resources, left, right);
                QuickSort(distance, resources, left, pi - 1);
                QuickSort(distance, resources, pi + 1, right);
            }

        }
        private int Partition(List<float> distance, List<Resource> resources, int left, int right)
        {
            float pivot = distance[right];

            int i = (left - 1);

            for (int j = left; j <= right - 1; j++)
            {
                if (distance[j] < pivot)
                {
                    i++;
                    SwapListElement(distance, i, j);
                    SwapListElement(resources, i, j);
                }
            }
            SwapListElement(distance, i + 1, right);
            SwapListElement(resources, i + 1, right);
            return (i + 1);
        }
        private void SwapListElement<T>(List<T> objectList, int i, int j)
        {
            T temp = objectList[i];
            objectList[i] = objectList[j];
            objectList[j] = temp;
        }
    }
}
