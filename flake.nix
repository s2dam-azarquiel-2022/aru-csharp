{
  description = "C# setup";
  inputs = {
    nixpkgs.url = "nixpkgs/nixos-22.05";
  };

  outputs = { self, nixpkgs }:
    let
      system = "x86_64-linux";
      pkgs = nixpkgs.legacyPackages.${system};
    in {
      devShells.${system}.default = pkgs.mkShell {
        buildInputs = [
          # For emacs
          pkgs.dotnet-sdk
        ];
        shellHook = ''
          export DOTNET_ROOT="${pkgs.dotnet-sdk}"
        '';
      };
  };
}
