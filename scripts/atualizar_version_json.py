import json
import os


def main() -> None:
    tag = os.environ["TAG_NAME"]
    versao = tag[1:] if tag.startswith("v") else tag

    repo = os.environ["REPO"]
    url_instalador = f"https://github.com/{repo}/releases/download/{tag}/ElsEvo-Setup.exe"

    dados = {
        "versao": versao,
        "url": url_instalador,
        "notas": os.environ.get("RELEASE_NOTES") or "",
    }

    with open("version.json", "w", encoding="utf-8") as f:
        json.dump(dados, f, indent=2, ensure_ascii=False)
        f.write("\n")

    print(f"version.json atualizado para a versão {versao} ({url_instalador})")


if __name__ == "__main__":
    main()
