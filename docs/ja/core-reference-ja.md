# コアリファレンス

- [コアリファレンス](#%E3%82%B3%E3%82%A2%E3%83%AA%E3%83%95%E3%82%A1%E3%83%AC%E3%83%B3%E3%82%B9)
  - [1. 概要](#1-%E6%A6%82%E8%A6%81)
  - [1.1 Ceciliaとは](#11-cecilia%E3%81%A8%E3%81%AF)
  - [字句構造](#%E5%AD%97%E5%8F%A5%E6%A7%8B%E9%80%A0)
    - [プログラムの構造](#%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%A0%E3%81%AE%E6%A7%8B%E9%80%A0)
    - [キーワード](#%E3%82%AD%E3%83%BC%E3%83%AF%E3%83%BC%E3%83%89)

## 1. 概要

## 1.1 Ceciliaとは

この文書では、プログラミング言語「Cecilia」のコア規格を解説する。  
  
Ceciliaという名の由来は、キリスト教の聖人である聖セシリアに由来している。  
この言語は、メタプログラミング、関数型プログラミング、オブジェクト指向などを内包するマルチパラダイム言語である。  
  
この文書は、2019年4月現在において未完成である。

## 字句構造

### プログラムの構造

Ceciliaのプログラムは主に、**名前空間**、**宣言**、**式**、**オブジェクト**などで構成される。  
プログラムは、１つ以上のソースファイルで構成される。ソースファイルにはソースコードが記載され、  
Ceciliaコンパイラにおける最も最小の翻訳単位である。

### キーワード

予約語
```
bool
char
string
object
void
int8
int16
int32
int64
uint8
uint16
uint32
uint64
half
float
double
namespace
public
private
internal
using
var
const
switch
loop
macro
```