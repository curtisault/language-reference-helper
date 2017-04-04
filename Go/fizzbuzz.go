package main

import "fmt"

func main() {

	l := getNumsList()
	m := createMap()

	checkMap(l, m)
}

func getNumsList() []int {
	b := []int{1, 7, 3, 14, 15, 33, 60, 22}
	return b
}

func createMap() map[int]string {
	m := make(map[int]string)
	m[3] = "Fizzles"
	m[5] = "Buzzles"
	m[15] = "Fizzbuzzles"
	return m
}

func checkMap(a []int, b map[int]string) {
	for i := 0; i < len(a); i++ {
		if val, ok := b[i]; ok {
			fmt.Println(val)
		} else{
			fmt.Println(a[i])
		}
	}
}
