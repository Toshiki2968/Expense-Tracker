# Expense Tracker CLI 

## 概要  
Expense Tracker CLI は、[roadmap.sh](https://roadmap.sh/projects/expense-tracker)のコマンドラインで経費の管理ができるサンプルアプリケーションです。  
経費の追加、一覧表示、削除、月ごとの集計などの機能を提供します。  

## 環境構築  

### 1. 必要なツール  
- .NET SDK（バージョン 8.0 以上）  
- C# 開発環境（Visual Studio, VS Code など）  

### 2. プロジェクトのセットアップ  
```sh
git clone https://github.com/Toshiki2968/Expense-Tracker.git
cd Expense-Tracker
dotnet build
dotnet run
```

## 機能詳細
### 経費の追加機能

新しい経費を登録します。  

#### コマンド形式  
```sh
expense-tracker add --description "{説明}" --amount {金額} --category "{カテゴリ}"
```

#### 入力例
```sh
expense-tracker add --description "Lunch" --amount 20 --category "Food"
```
#### 出力例
```sh
# Expense added successfully (ID: 1)
```

# 経費のリスト取得機能
#### コマンド形式
```sh
expense-tracker list
```

#### 入力例
```sh
expense-tracker list
```
#### 出力例
```sh
# ID  Date       Description  Amount Category
# 1   2024-08-06  Lunch        $20    Food
```

# 経費の合計取得機能
#### コマンド形式  
```sh
expense-tracker summary
```

#### 入力例
```sh
expense-tracker summary
```
#### 出力例
```sh
# Total expenses: $30
```

# 経費の削除機能
#### コマンド形式
```sh
expense-tracker delete --id {id}
```

#### 入力例
```sh
expense-tracker delete --id 1
```
#### 出力例
```sh
# Expense added successfully (ID: 1)
```
