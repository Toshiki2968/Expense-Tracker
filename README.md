# Expense Tracker CLI - README  

## 概要  
Expense Tracker CLI は、[roadmap.sh](https://roadmap.sh/projects/expense-tracker)のコマンドラインで経費の管理ができるサンプルアプリケーションです。  
経費の追加、一覧表示、削除、月ごとの集計などの機能を提供します。  

## 環境構築  

### 1. 必要なツール  
- .NET SDK（バージョン 8.0 以上）  
- C# 開発環境（Visual Studio, VS Code など）  

### 2. プロジェクトのセットアップ  
```sh
git clone <リポジトリURL>
cd ExpenseTracker
dotnet build
```

## 機能詳細
# 経費の追加機能

新しい経費を登録します。  

### コマンド形式  
```sh
expense-tracker add --description "{説明}" --amount {金額} --category "{カテゴリ}"
```

# 経費のリスト取得機能

# 経費の合計取得機能

# 経費の削除機能
