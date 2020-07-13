using System;
using System.Linq;

public static class CPD {
    public static int BinarySearchInCPD(float[] cpd, float key) {
        if (key < 0f) return -1;

        int left = 0;
        int right = cpd.Length - 1;
        int mid = left + (right - left) / 2;

        float[] zero_to_mid = new float[mid];
        Array.Copy(cpd, 0, zero_to_mid, 0, mid);
        float L_mid = zero_to_mid.Sum();

        while (right >= left) {
            float R_mid = L_mid + cpd[mid];
            if ((L_mid <= key && key < R_mid) || (key == R_mid && mid == cpd.Length - 1)) {
                return mid;
            } else if (key < L_mid) {
                right = mid - 1;
                mid = left + (right - left) / 2;
                float[] next_mid_to_mid = new float[right - mid];
                Array.Copy(cpd, mid + 1, next_mid_to_mid, 0, right - mid);
                R_mid = L_mid - next_mid_to_mid.Sum();
                L_mid = R_mid - cpd[mid];
            } else {
                left = mid + 1;
                mid = left + (right - left) / 2;
                if (mid >= cpd.Length) break;
                float[] mid_to_next_mid = new float[mid - left];
                Array.Copy(cpd, left, mid_to_next_mid, 0, mid - left);
                L_mid = R_mid + mid_to_next_mid.Sum();
                R_mid = L_mid + cpd[mid];
            }
        }
        return -1;
    }
}
