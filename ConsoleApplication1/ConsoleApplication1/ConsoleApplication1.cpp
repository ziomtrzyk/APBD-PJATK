#include <iostream>

static double meth(int x[], int size) {
    if (size == 0) return 0;

    int sum = 0;

    for (int i = 0; i < size; i++) {
        sum += x[i];
    }
    return static_cast<double>(sum) / size;
}


int main()
{
    std::cout << "Hello GitHub!\n";

    int arr[] = { 1, 2, 3, 4, 5 };

    double x = meth(arr, 5);

    std::cout << x;

}


