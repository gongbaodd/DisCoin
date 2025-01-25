using UnityEngine;
using UnityEngine.UI;

public class ChartController : MonoBehaviour
{
    public RectTransform chartContainer; // Assign a RectTransform (Panel) in the canvas
    public Sprite circleSprite;         // Assign a circle image for points

    public float[] dataPoints;

    public void UpdateData(float[] data) {
        dataPoints = data;
        ClearChild();
        DrawLineChart(dataPoints);
    }

    private void ClearChild() {
        int childCount = chartContainer.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Destroy(chartContainer.GetChild(i).gameObject);
        }
    }

    private void DrawLineChart(float[] values)
    {
        float chartWidth = chartContainer.sizeDelta.x;
        float chartHeight = chartContainer.sizeDelta.y;
        float xSpacing = chartWidth / (values.Length - 1);

        float maxValue = Mathf.Max(values); // Find the highest value for scaling

        Vector2 prevPoint = Vector2.zero;

        for (int i = 0; i < values.Length; i++)
        {
            float xPos = i * xSpacing;
            float yPos = values[i] / maxValue * chartHeight;

            Vector2 newPoint = new Vector2(xPos, yPos);

            CreateCircle(newPoint);

            if (i > 0)
            {
                CreateLine(prevPoint, newPoint);
            }

            prevPoint = newPoint;
        }
    }

    private void CreateCircle(Vector2 position)
    {
        GameObject circle = new GameObject("Circle", typeof(Image));
        circle.transform.SetParent(chartContainer, false);
        circle.GetComponent<Image>().sprite = circleSprite;

        RectTransform rectTransform = circle.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(10, 10); // Adjust circle size
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    private void CreateLine(Vector2 startPoint, Vector2 endPoint)
    {
        GameObject line = new GameObject("Line", typeof(Image));
        line.transform.SetParent(chartContainer, false);
        line.GetComponent<Image>().color = Color.black; // Set line color

        RectTransform rectTransform = line.GetComponent<RectTransform>();
        Vector2 direction = (endPoint - startPoint).normalized;
        float distance = Vector2.Distance(startPoint, endPoint);

        rectTransform.sizeDelta = new Vector2(distance, 3); // Line thickness
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.anchoredPosition = startPoint + direction * distance * 0.5f;
        rectTransform.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}
