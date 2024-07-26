#include <iostream>
#include <set>
#include <unordered_set>

using namespace std;

bool palindrome(string inputString, string trashString)
{
    unordered_set<char> ignoreChars;
    int trashStringLen = trashString.length();
    for (int i = 0; i < trashStringLen; i++)
    {
        ignoreChars.insert(trashString[i]);
    }

    int start = 0,
        end = inputString.length() - 1;

    while (start < end)
    {
        while (ignoreChars.find(inputString[start]) != ignoreChars.end() && start < end)
        {
            start++;
        }

        while (ignoreChars.find(inputString[end]) != ignoreChars.end() && start < end)
        {
            end--;
        }

        if (start > end || inputString[start] != inputString[end])
        {
            return false;
        }

        start++;
        end--;
    }

    return true;
}

int main()
{
    string inputString, trashString;
    cout << "Input String: ";
    cin >> inputString;
    cout << "Trash String: ";
    cin >> trashString;

    cout << (palindrome(inputString, trashString) ? "true" : "false") << endl;
}