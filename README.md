# clippy.net

Build:
```shell
dotnet publish -c Release --self-contained --runtime linux-x64
```

Example usage:
```shell
$ echo "May i help you?" | ./Clippy
╭──╮    ╭─────────────────╮
│  │    │ May i help you? │
@  @  ╭ ╰─────────────────╯
││ ││ │
││ ││ ╯
│╰─╯│
╰───╯
```

```shell
$ ls -la | ./Clippy
╭──╮    ╭────────────────────────────────────────────────────────────╮
│  │    │ total 84                                                   │
@  @  ╭ │ drwxr-xr-x  5 $USER $USER  4096 Sep 27 00:07 .             │
││ ││ │ │ drwxrwxr-x 34 $USER $USER  4096 Sep 26 23:12 ..            │
││ ││ ╯ │ drwxr-xr-x  4 $USER $USER  4096 Sep 27 00:01 bin           │
│╰─╯│   │ -rw-r--r--  1 $USER $USER   342 Sep 27 00:03 Clippy.csproj │
╰───╯   │ -rw-r--r--  1 $USER $USER   106 Sep 27 00:00 .editorconfig │
        │ drwxr-xr-x  8 $USER $USER  4096 Sep 27 00:09 .git          │
        │ -rw-r--r--  1 $USER $USER  5764 Sep 27 00:00 .gitignore    │
        │ -rw-r--r--  1 $USER $USER 35149 Sep 27 00:06 LICENSE       │
        │ drwxr-xr-x  4 $USER $USER  4096 Sep 27 00:02 obj           │
        │ -rw-r--r--  1 $USER $USER  4402 Sep 26 23:59 Program.cs    │
        │ -rw-r--r--  1 $USER $USER   309 Sep 27 00:07 README.md     │
        ╰────────────────────────────────────────────────────────────╯
```
